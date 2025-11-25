# Azure Storage
resource "azurerm_storage_account" "example" {
  name                     = "${var.az_function_storage_account_name}"
  resource_group_name      = data.azurerm_resource_group.rg.name
  location                 = data.azurerm_resource_group.rg.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

# Azure Service Plan
resource "azurerm_service_plan" "example" {
  name                = "rk-app-service-plan01"
  resource_group_name = data.azurerm_resource_group.rg.name
  location            = data.azurerm_resource_group.rg.location
  os_type             = "Windows"
  # Windows Premium Plan
  sku_name            = "P1v2"
}

# Azure Function
resource "azurerm_windows_function_app" "example_az_func" {
  name                = "${var.azurerm_windows_function_app_name}"
  resource_group_name = data.azurerm_resource_group.rg.name
  location            = data.azurerm_resource_group.rg.location
  storage_account_name = azurerm_storage_account.example.name
  storage_account_access_key = azurerm_storage_account.example.primary_access_key
  service_plan_id      = azurerm_service_plan.example.id

  # Virtual network configuration
  virtual_network_subnet_id = azurerm_subnet.az_func_subnet_int.id

  public_network_access_enabled = true

  app_settings = {
    "WEBSITE_RUN_FROM_PACKAGE" = 1
    "FUNCTIONS_WORKER_RUNTIME" = "dotnet-isolated",
  }

  site_config {
    use_32_bit_worker = false
    always_on = true
    application_stack {
      dotnet_version = "v8.0"
    }
  }

  lifecycle {
    ignore_changes = [ app_settings ]
  }
}

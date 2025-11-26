# Private Endpoint and Network for SignalR Service
resource "azurerm_network_security_group" "az_signalr_network_sg" {
  name                = "example-security-group"
  location            = data.azurerm_resource_group.rg.location
  resource_group_name = data.azurerm_resource_group.rg.name
}

# Virtual Network
resource "azurerm_virtual_network" "az_signalr_network" {
  name                = "az-signalr-vn-vnet"
  address_space       = ["10.0.0.0/16"]
  location            = data.azurerm_resource_group.rg.location
  resource_group_name = data.azurerm_resource_group.rg.name
}

# Subnet: private Endpoint for SignalR
resource "azurerm_subnet" "az_signalr_subnet_pe" {
  name                 = "subnet-pe-az-signalr"
  resource_group_name  = data.azurerm_resource_group.rg.name
  virtual_network_name = azurerm_virtual_network.az_signalr_network.name
  address_prefixes     = ["10.0.2.0/24"]

  private_link_service_network_policies_enabled = true
}

# Azure Function
# Subnet: internal
resource "azurerm_subnet" "az_func_subnet_int" {
  name                 = "subnet-int-az-func"
  resource_group_name  = data.azurerm_resource_group.rg.name
  virtual_network_name = azurerm_virtual_network.az_signalr_network.name
  address_prefixes     = ["10.0.3.0/24"]

  private_link_service_network_policies_enabled = true

  delegation {
    name = "example-delegation"

    service_delegation {
      name    = "Microsoft.Web/serverFarms"
      actions = ["Microsoft.Network/virtualNetworks/subnets/action"]
    }
  }
  service_endpoints = [
    "Microsoft.EventHub",
    "Microsoft.KeyVault",
    "Microsoft.ServiceBus",
    "Microsoft.Storage",
    "Microsoft.Web",
  ]
}
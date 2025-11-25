environment = "test"
resource_group_name="RG-ExampleAzureFunctions"
az_function_storage_account_name="stdexampleazfunc"
azurerm_windows_function_app_name="example-az-func"
az_function_pv_svc_connection="pe-svc-exampleazfunc"
pv_endpoint_name="pe-func-exampleazfunc"
az_function_private_dns_zone_group="/subscriptions/38df8db5-1d29-4087-9e88-16d38de1e276/resourceGroups/RG-ExampleAzureFunctions/providers/Microsoft.Network/privateDnsZones/privatelink.azurewebsites.net"

# SignalR Settings
signalr_name = "signalr-test-example"
allowed_origins = ["http://localhost:4200", "https://example-az-func.azurewebsites.net"]
public_network_access_enabled = false

network_interface_signalr = "nic-signalr-test-example"
pv_svc_connection_signalr="pe-signalr-test-example"
pv_endpoint_static_ip="10.0.2.11"
pv_endpoint_name = "pe-signalr-test-example"
pv_dns_zone_group_signalr = "signalr-dns-zone-group"

tags = {
  environment = "test"
  project     = "signalr-example"
}
environment = "test"
resource_group_name="rg-signal-example"
az_function_storage_account_name="stdexampleazfunc"
azurerm_windows_function_app_name="example-az-func"

# SignalR Settings
signalr_name = "signalr-test-example"
allowed_origins = ["https://example-az-func.azurewebsites.net"]
public_network_access_enabled = false

network_interface_signalr = "nic-signalr-test-example"
pv_svc_connection_signalr="pe-signalr-test-example"
pv_endpoint_static_ip="10.0.2.11"
pv_endpoint_name = "pe-signalr-test-example"
pv_dns_zone_group_signalr = "signalr-dns-zone-group"
pv_endpoint_name_signalr = "pe-signalr-test-example"
tags = {
  environment = "test"
  project     = "signalr-example"
}
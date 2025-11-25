variable "environment" {
  type = string
}

variable "resource_group_name" {
  type = string
}

variable "az_function_storage_account_name" {
  type = string
  default = ""
}

variable "azurerm_windows_function_app_name" {
  type = string
  default = ""
}

variable "tags" {
  type = map(string)
  default = {
    app-name = "Example Az Function"
  }
}

# SignalR Variables
variable "signalr_name" {
    type = string
}

variable "allowed_origins" {
  type = list(string)
  default = []
}

variable "pv_endpoint_name_signalr" {
  type = string
  default = ""
}
variable "pv_svc_connection_signalr" {
  type = string
  default = ""
}

variable "static_ip_signalr" {
  type = string
  default = ""
}

variable "pv_dns_zone_group_signalr" {
  type = string
  default = "signalr-dns-zone-group"
}

variable "network_interface_signalr" {
  type = string
  default = ""
}

variable "public_network_access_enabled" {
  type = bool
  default = false
}
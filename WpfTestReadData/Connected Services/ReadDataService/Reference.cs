﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfTestReadData.ReadDataService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReadDataService.IReadData")]
    public interface IReadData {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadData/GetHousdetails", ReplyAction="http://tempuri.org/IReadData/GetHousdetailsResponse")]
        System.Data.DataTable GetHousdetails(string _houseID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadData/GetHousdetails", ReplyAction="http://tempuri.org/IReadData/GetHousdetailsResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetHousdetailsAsync(string _houseID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadData/GetHouseDetails", ReplyAction="http://tempuri.org/IReadData/GetHouseDetailsResponse")]
        System.Data.DataTable GetHouseDetails();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadData/GetHouseDetails", ReplyAction="http://tempuri.org/IReadData/GetHouseDetailsResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetHouseDetailsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReadDataChannel : WpfTestReadData.ReadDataService.IReadData, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReadDataClient : System.ServiceModel.ClientBase<WpfTestReadData.ReadDataService.IReadData>, WpfTestReadData.ReadDataService.IReadData {
        
        public ReadDataClient() {
        }
        
        public ReadDataClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReadDataClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReadDataClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReadDataClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataTable GetHousdetails(string _houseID) {
            return base.Channel.GetHousdetails(_houseID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetHousdetailsAsync(string _houseID) {
            return base.Channel.GetHousdetailsAsync(_houseID);
        }
        
        public System.Data.DataTable GetHouseDetails() {
            return base.Channel.GetHouseDetails();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetHouseDetailsAsync() {
            return base.Channel.GetHouseDetailsAsync();
        }
    }
}
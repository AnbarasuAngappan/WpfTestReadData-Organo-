//var _meterSetting = datarowItem.Field<string>("OwnerName");
//Account tem = Newtonsoft.Json.JsonConvert.DeserializeObject<Account>(_meterSetting);
//var a = tem.Email;



<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
    </startup>
    <system.serviceModel>
        <bindings>
            <basicHttpBinding>
                <binding name="BasicHttpBinding_IReadData" maxReceivedMessageSize="20000000" maxBufferSize="20000000" maxBufferPoolSize="20000000" />
            </basicHttpBinding>
        </bindings>
        <client>
            <endpoint address="http://localhost:50766/" binding="basicHttpBinding"
                bindingConfiguration="BasicHttpBinding_IReadData" contract="ReadDataService.IReadData"
                name="BasicHttpBinding_IReadData" />
        </client>
    </system.serviceModel>
</configuration>
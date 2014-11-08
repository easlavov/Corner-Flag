1. Reference the .dll in your .NET application
2. Add the following to your web.config/app.config depending on type of application you are making. It should be put in the "Configuration" node:

    <system.serviceModel>
        <bindings>
            <basicHttpBinding>
                <binding name="FootballDataSoap" maxReceivedMessageSize = "1000000" />
                <binding name="FootballDataDemoSoap" maxReceivedMessageSize = "1000000" />
            </basicHttpBinding>
        </bindings>
        <client>
            <endpoint address="http://www.xmlsoccer.com/FootballData.asmx"
                binding="basicHttpBinding" bindingConfiguration="FootballDataSoap"
                contract="ProService.FootballDataSoap" name="FootballDataSoap" />
            <endpoint address="http://www.xmlsoccer.com/FootballDataDemo.asmx"
                binding="basicHttpBinding" bindingConfiguration="FootballDataDemoSoap"
                contract="DemoService.FootballDataDemoSoap" name="FootballDataDemoSoap" />
        </client>
    </system.serviceModel>

3. Check out http://www.xmlsoccer.com and http://xmlsoccer.wikia.com/wiki/.NET_.dll_library_class_file_tutorial for more info.

Happy coding!
Michael
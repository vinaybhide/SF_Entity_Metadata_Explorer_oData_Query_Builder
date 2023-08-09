# SuccessFactors oData entity metadata explorer and oData query builder
This is .Net standard framework based windows form application developed using C# & windows forms.
It allows user to provide SuccessFactors configuration parameters for establishing connection to specific SuccessFactors server
You will need to make sure you have values for all of the parameters. 
  You can either create an XML configuration file as per the format give in SF_Metadata_Config.xml and use 'Load Configuration"
  Or you can enter all the values in their respective fields and then save them to a config file for subsequent usage
You can load previously saved metadata or you can fetch metadata from SuccessFactors for loading the same into application
Once the metadata is loaded, you can see information about each Entity in mutiple grid views populated based on type of information
Application allows you to search based on several fields available in Metadata
User can select key, property as well as propogation fields from their specific grid views and then click on "Build Query" buton to build odata query
Application also allows user to execute an oData api query

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EVEMon.Gateways.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.0.1.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
		[global::System.Configuration.ApplicationScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("http://localhost:38164")]
		public string InternalServerBaseURL
		{
			get
			{
				return ((string)(this["InternalServerBaseURL"]));
			}
		}

		[global::System.Configuration.ApplicationScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("https://login.eveonline.com/oauth")]
		public string LoginServerBaseUrl
		{
			get
			{
				return ((string)(this["LoginServerBaseURL"]));
			}
		}

		[global::System.Configuration.ApplicationScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
<string>publicData</string>
<string>characterStatsRead</string>
<string>characterFactionalWarfareRead</string>
<string>characterIndustryJobsRead</string>
<string>characterMarketOrdersRead</string>
<string>characterNotificationsRead</string>
<string>characterAccountRead</string>
<string>characterContractsRead</string>
<string>characterOpportunitiesRead</string>
<string>characterLoyaltyPointsRead</string>
<string>esi-calendar.respond_calendar_events.v1</string>
<string>esi-calendar.read_calendar_events.v1</string>
<string>esi-characters.read_contacts.v1</string>
<string>esi-characters.read_loyalty.v1</string>
<string>esi-characters.read_opportunities.v1</string>
<string>esi-characters.read_medals.v1</string>
<string>esi-characters.read_standings.v1</string>
<string>esi-characters.read_agents_research.v1</string>
<string>esi-clones.read_clones.v1</string>
<string>esi-location.read_location.v1</string>
<string>esi-location.read_ship_type.v1</string>
<string>esi-mail.read_mail.v1</string>
<string>esi-search.search_structures.v1</string>
<string>esi-skills.read_skills.v1</string>
<string>esi-skills.read_skillqueue.v1</string>
<string>esi-wallet.read_character_wallet.v1</string>
<string>esi-universe.read_structures.v1</string>
<string>esi-bookmarks.read_character_bookmarks.v1</string>
<string>esi-killmails.read_killmails.v1</string>
<string>esi-assets.read_assets.v1</string>
<string>esi-planets.manage_planets.v1</string>
<string>esi-markets.structure_markets.v1</string>
<string>esi-characters.read_standings.v1</string>
</ArrayOfString>")]
		public global::System.Collections.Specialized.StringCollection Scopes
		{
			get
			{
				return ((global::System.Collections.Specialized.StringCollection)(this["Scopes"]));
			}
		}

		[global::System.Configuration.ApplicationScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("6744fb2bede34f02a21a8becb3647f45")]
		public string ClientID
		{
			get
			{
				return ((string)(this["ClientID"]));
			}
		}

		[global::System.Configuration.ApplicationScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("J2vJrNrHxLPHwdQksLVlL8gaCArKgZ6cCnegb5Jp")]
		public string ClientSecret
		{
			get
			{
				return ((string)(this["ClientSecret"]));
			}
		}
	}
}
function UpdateHosts($sitename) {
	Write-Host "Updating the windows hosts file"
	if (Get-Content C:\Windows\System32\drivers\etc\hosts | Select-String "127.0.0.1	$sitename" -quiet) { 
	    Write-Host "$sitename already defined in hosts file"
	} else {
	    Add-Content C:\Windows\System32\drivers\etc\hosts "`n127.0.0.1	$sitename"
	}
	
	Write-Host "Finished updating the windows hosts file"    
}

function UpdateBindings($sitename) {
    New-WebBinding -Name $env:SiteName -IP "*" -Port 80 -Protocol http -HostHeader $sitename
}

$hosts = @("microsoft.demo", "finance.demo", "university.demo")
foreach($hostName in $hosts) {
    UpdateHosts $hostName
    UpdateBindings $hostName
}
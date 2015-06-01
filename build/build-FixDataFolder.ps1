param (
	[string]$config = "c:\websites\spitfire\website\web.config",
    [string]$folder = "c:\websites\spitfire\data"
)

[xml]$doc = Get-Content $config     
$nodes = $doc.SelectNodes("/configuration/sitecore/sc.variable[1]") 

$nodes[0].value = $folder
$doc.Save($config)
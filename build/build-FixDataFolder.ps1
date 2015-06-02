param ([string]$config, [string]$folder)

[xml]$doc = Get-Content $config     
$nodes = $doc.SelectNodes("/configuration/sitecore/sc.variable[1]") 

$nodes[0].value = $folder
$doc.Save($config)
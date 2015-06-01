param ([string]$config, [string]$folder)

$length = $folder.Length
$folder = $folder.Substring(0, $length - 5) + "src\serialization"

[xml]$doc = Get-Content $config     
$nodes = $doc.SelectNodes("/configuration/sitecore/unicorn/defaults/serializationProvider") 
$nodes[0].rootPath = $folder

$doc.Save($config)
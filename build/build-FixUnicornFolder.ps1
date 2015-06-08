param ([string]$config, [string]$folder)

$length = $folder.Length
$folder = $folder.Substring(0, $length - 5) + "src\serialization"

[xml]$doc = Get-Content $config     

$ns = New-Object System.Xml.XmlNamespaceManager($doc.NameTable)
$ns.AddNamespace("patch", "http://www.sitecore.net/xmlconfig/")
$nodes = $doc.SelectNodes("/configuration/sitecore/unicorn/defaults/serializationProvider/patch:attribute", $ns) 
$nodes[0].'#text' = $folder
$doc.Save($config)
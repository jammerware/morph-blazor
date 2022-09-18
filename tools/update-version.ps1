param([string]$ProjectDir, [string]$ProjectPath, [string]$VersionElement);

$VersionElement = if ($VersionElement) {  $VersionElement } else { "Version" };
$currentDate = get-date -format yyyy.MM.dd.HHmm;
$find = "<${VersionElement}>(.|\n)*?</${VersionElement}>";
$replace = "<${VersionElement}>" + $currentDate + "</${VersionElement}>";
$csproj = Get-Content $ProjectPath
$csprojUpdated = $csproj -replace $find, $replace

Set-Content -Path $ProjectPath -Value $csprojUpdated
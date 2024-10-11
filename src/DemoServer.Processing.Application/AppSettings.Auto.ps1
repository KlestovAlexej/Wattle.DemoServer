param(
[parameter(Mandatory=$true)] 
[ValidateScript({Test-Path $_ -PathType 'Container'})]    
[string]$projectPath)

[Console]::OutputEncoding = [System.Text.Encoding]::UTF8

$configPath = "$($projectPath)appsettings.json"
$config = (Get-Content $configPath -encoding UTF8) | ConvertFrom-Json

# { SystemSettings
$arg = "-S:SystemSettings"

Write-Host "----------------------------------------------------------------------"
Write-Host "| $($arg)"

$cmd = "dotnet"
$output = & $cmd "$($projectPath)Acme.DemoServer.Processing.Application.dll" $arg
$settings = $output | ConvertFrom-Json
$config.SystemSettings = $settings
# } SystemSettings

# { OpenTelemetry
$arg = "-S:OpenTelemetry"

Write-Host "----------------------------------------------------------------------"
Write-Host "| $($arg)"

$cmd = "dotnet"
$output = & $cmd "$($projectPath)Acme.DemoServer.Processing.Application.dll" $arg
$settings = $output | ConvertFrom-Json
$config.OpenTelemetry = $settings
# } OpenTelemetry

$config | ConvertTo-Json -Depth 100 | Out-File -FilePath $configPath

Write-Host "----------------------------------------------------------------------"
Write-Host "| $($configPath)"
Write-Host "----------------------------------------------------------------------"


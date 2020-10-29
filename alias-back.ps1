$baseFiles = @() + (Get-ChildItem -Path . -Include docker-compose-files.txt -Force -Recurse | ForEach-Object {$_.FullName})

$devFiles = @() + (Get-ChildItem -Path . -Include docker-compose-files.development.txt -Force -Recurse | ForEach-Object {$_.FullName})
$prodFiles = @() + (Get-ChildItem -Path . -Include docker-compose.production-files.txt -Force -Recurse | ForEach-Object {$_.FullName})

$devAllFiles =  @() + ($baseFiles + $devFiles | Where-Object {$_})
$prodAllFiles = @() + ($baseFiles + $prodFiles | Where-Object {$_})

$currentDev = Get-Content $devAllFiles | ForEach-Object { Resolve-Path -Path $_ } | ForEach-Object { "-f $_" }
$currentProd = Get-Content $prodAllFiles | ForEach-Object { Resolve-Path -Path $_ } | ForEach-Object { "-f $_" }

Write-Output dev
$currentDev

Write-Host prod
$currentProd

$devDockerFiles = [string]::Join(" ", $currentDev)
$prodDockerFiles = [string]::Join(" ", $currentProd)

$devCommand = "docker-compose $devDockerFiles"
$prodCommand = "docker-compose $prodDockerFiles"

function DevelopmentBackendDockerCompose {
       Invoke-Expression "$devCommand $args"
}

function ProductionBackendDockerCompose {
       Invoke-Expression "$prodCommand $args"
}
Set-Alias -Name bdc DevelopmentBackendDockerCompose
Set-Alias -Name pbdc ProductionBackendDockerCompose

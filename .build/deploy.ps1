Import-Module WebAdministration

$PoolName = "ActionsDemo"
$status = Get-WebAppPoolState -name $PoolName

if ($status.Value -ne "Stopped") {
    Stop-WebAppPool -name $PoolName
}

$currentRetry = 0;
$success = $false;
do {
    $status = Get-WebAppPoolState -name $PoolName
    if ($status.Value -eq "Stopped") {
        $success = $true;
    }
    Start-Sleep -s 5
    $currentRetry = $currentRetry + 1;
    write-host "Waiting for site stop:$currentRetry"
}
while (!$success -and $currentRetry -le 4)

if ($success) {
    Get-ChildItem ./app_publish/ -Exclude "appsettings.json" | Copy-Item -Destination C:/WebSites/GithubActions -Recurse -Force
}
else {
    write-host "Error: stop website failed"
}

write-host "starting web site"
$status = Get-WebAppPoolState -name $PoolName

if ($status.Value -eq "Stopped") {
    Start-WebAppPool -name $PoolName
}

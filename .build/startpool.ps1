param 
(
	[string]$AppPoolName = "ActionsDemo"
)

Import-Module WebAdministration

$AppPoolName = "ActionsDemo"
$status = Get-WebAppPoolState -name $AppPoolName

if ($status.Value -ne "Started") {
    Start-WebAppPool -name $AppPoolName
}
else {
    exit 0
}

$currentRetry = 0;
$success = $false;
do {
    $status = Get-WebAppPoolState -name $AppPoolName
    if ($status.Value -eq "Started") {
        $success = $true;
    }
    Start-Sleep -s 5
    $currentRetry = $currentRetry + 1;
    write-host "Waiting for pool start:$currentRetry"
}
while (!$success -and $currentRetry -le 4)

if ($success) {
    exit 0
}
else {
    write-host "start pool filed"
    exit 1
}

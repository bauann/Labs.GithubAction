param 
(
	[string]$AppPoolName = "ActionsDemo"
)

Import-Module WebAdministration

$AppPoolName = "ActionsDemo"
$status = Get-WebAppPoolState -name $AppPoolName

if ($status.Value -ne "Stopped") {
    Stop-WebAppPool -name $AppPoolName
}
else {
    exit 0
}

$currentRetry = 0;
$success = $false;
do {
    $status = Get-WebAppPoolState -name $AppPoolName
    if ($status.Value -eq "Stopped") {
        $success = $true;
    }
    Start-Sleep -s 5
    $currentRetry = $currentRetry + 1;
    write-host "Waiting for pool stop:$currentRetry"
}
while (!$success -and $currentRetry -le 4)

if ($success) {
    exit 0
}
else {
    write-host "stop pool filed"
    exit 1
}

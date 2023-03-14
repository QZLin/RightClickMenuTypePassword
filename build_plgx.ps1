Push-Location $PSScriptRoot
&"$PSScriptRoot/../../keepass" --plgx-create (Get-Location)
Pop-Location

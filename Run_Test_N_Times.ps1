param (
[string] $testName="MyHealthPageCompleteTest_RT07843"
)

$numberOfRuns=1
$workspace="$env:WORKSPACE"
$testProjectPath="$workspace\Research\GWP.TestAutomation\GWPA.Test.MSTest\bin\Debug\GWPA.Test.MSTest.dll"
$testProjectContainer="/testcontainer: $testProjectPath"
$testContainerPath="/testcontainer: $workspace\Research\GWP.TestAutomation\GWP.TestAtuomation.Framework\bin\Debug\Framework.dll"
$detailParams="/detail:Stderr /detail:errormessage /detail:Description /detail:errorstacktrace"
$msTestPath="C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\mstest.exe"
$msBuildPath="C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe"
$appConfigFile="C:\development\atlas\Research\GWP.TestAutomation\GWPA.Test.MSTest\Settings.xml"
$solutionPath="$workspace\Research\GWP.TestAutomation\GWPA.Test.MSTest\GWPA.Test.MSTest.csproj"
$phantomPass=0
$chromePass=0
$firefoxPass=0

write-host ""
write-host "Testing:" $testName
(Get-Content $appConfigFile) -replace '>Firefox<', '>PhantomJS<' | Set-Content $appConfigFile
(Get-Content $appConfigFile) -replace '>Chrome<', '>PhantomJS<' | Set-Content $appConfigFile

write-host ""
write-host "----------------------------PhantomJS---------------------------------"
#& $msBuildPath /verbosity:quiet $solutionPath
for($i=1; $i -le $numberOfRuns; $i++)
{	
	write-host ""
	write-host "----------------------------PhantomJS:"  $i "---------------------------------"
	$output = & $msTestPath $testProjectContainer $testContainerPath $detailParams /test:$testName
	if($output -like "*Failed*")
	{
		write-host "Result: Failed"
	}
	else
	{
		write-host "Result: Passed"
		$phantomPass++
	}
}

write-host ""
write-host "----------------------------Chrome---------------------------------"
(Get-Content $appConfigFile) -replace '>PhantomJS<', '>Chrome<' | Set-Content $appConfigFile
#& $msBuildPath /verbosity:quiet $solutionPath
for($i=1; $i -le $numberOfRuns; $i++)
{
	write-host ""
	write-host "----------------------------Chrome:" $i "---------------------------------"
	$output = & $msTestPath $testProjectContainer $testContainerPath $detailParams /test:$testName
	if($output -like "*Failed*")
	{
		write-host "Result: Failed"
	}
	else
	{
		write-host "Result: Passed"
		$chromePass++
	}
}

write-host ""
write-host "----------------------------Firefox---------------------------------"
(Get-Content $appConfigFile) -replace '>Chrome<', '>Firefox<' | Set-Content $appConfigFile
#& $msBuildPath /verbosity:quiet $solutionPath
for($i=1; $i -le $numberOfRuns; $i++)
{
	write-host ""
	write-host "----------------------------Firefox:" $i "---------------------------------"
	$output = & $msTestPath $testProjectContainer $testContainerPath $detailParams /test:$testName
	if($output -like "*Failed*")
	{
		write-host "Result: Failed"
	}
	else
	{
		write-host "Result: Passed"
		$firefoxPass++
	}
}

(Get-Content $appConfigFile) -replace '>Firefox<', '>PhantomJS<' | Set-Content $appConfigFile
& $msBuildPath /verbosity:quiet $solutionPath

write-host "------------------------------------Results---------------------------------"
write-host "PhantomJS:" $phantomPass " Passed," ($numberOfRuns-$phantomPass) " Failed."
write-host "Chrome:" $chromePass " Passed,"($numberOfRuns-$chromePass) " Failed."
write-host "Firefox:" $firefoxPass " Passed,"($numberOfRuns-$firefoxPass) " Failed."
write-host "Press Any Key to Continue..."

$x = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")




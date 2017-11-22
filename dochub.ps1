param([switch]$h, [switch]$help, [switch]$i, [switch]$init, [switch]$b, [switch]$build)

if($h -or $help)
{
    Write-Host
    Write-Host "Dochub Help"
    Write-Host "---------------------"
    Write-Host "  -i|-init      Initializes the project based on the config.json."
    Write-Host "  -b|-build     Builds the project."
    Write-Host "  -h|-help      Displays this view."
    Write-Host

    return
}

$doNothing = dotnet.exe build -c Release "tools\src\Dochub.Console"

if($i -or $init)
{
    dotnet.exe .\"tools\src\Dochub.Console\bin\Release\netcoreapp2.0\Dochub.Console.dll" -init

    return
}

if($b -or $build)
{
    dotnet.exe .\"tools\src\Dochub.Console\bin\Release\netcoreapp2.0\Dochub.Console.dll" -build

    return
}
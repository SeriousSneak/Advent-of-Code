<#
Advent of Code 2019
Day 01
  
Programmer: Andrew Stobart
Part 1 finished on November 29, 2022
Part 2 finished on November 29, 2022

Code created using VS Code on both Mac and Windows.
#>

$StartTime = Get-Date

# Set variables
$theCountPart1 = 0
$theCountPart2 = 0

$singleModuleCalculationPart1 = 0
$singleModuleCalculationPart2 = 0

$loopAtLeastOnce = 0

$data = Get-Content "C:\Temp\Repos\Advent-of-Code\PowerShell\2019\Day 01\input.txt"


foreach ($number in $data)
{
    $singleModuleCalculationPart1 = [Math]::Floor(($number / 3) - 2)    # Floor causes the number to be rounded down to the nearest integer
    $theCountPart1 += $singleModuleCalculationPart1

    do
    {
        if ($loopAtLeastOnce -eq 1)
        {
            $singleModuleCalculationPart2 = [Math]::Floor(($singleModuleCalculationPart2 / 3) - 2)
        }
        else 
        {
            $singleModuleCalculationPart2 = [Math]::Floor(($number / 3) - 2)
            $loopAtLeastOnce = 1    
        }
        
        if ($singleModuleCalculationPart2 -gt 0)
        {
            $theCountPart2 += $singleModuleCalculationPart2
        }

    } while ($singleModuleCalculationPart2 -gt 0)

    $loopAtLeastOnce = 0

}

Write-Host "Part 1: The sum of the fuel requirements is $theCountPart1."
Write-Host "Part 2: The sum of the fuel requirements is $theCountPart2."
Write-Host ""

$RunTime = New-TimeSpan -Start $StartTime -End (get-date) 
Write-Host ("Execution time was {0} hours, {1} minutes, {2} seconds and {3} milliseconds." -f $RunTime.Hours,  $RunTime.Minutes,  $RunTime.Seconds,  $RunTime.Milliseconds)
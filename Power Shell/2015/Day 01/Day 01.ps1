<#
Advent of Code 2015
Day 01
  
Programmer: Andrew Stobart
Part 1 finished on October 30, 2022
Part 2 finished on November 19, 2022

Code created using VS Code on both Mac and Windows.
#>

$StartTime = Get-Date

# Set variables
$floor = 0
$chars
$position
$loopCounter = 0
$firstTimeInBasementPosition = 0 # will determine what character causes santa to enter the basement for the first time

$data = Get-Content ./input.txt
$chars = $data.ToCharArray()

foreach ($letter in $chars)
{
    $loopCounter++
    if ($letter -eq '(')
    {
        $floor++
    }
    else
    {
        $floor--
    }

    if ($floor -lt 0 -and $firstTimeInBasementPosition -eq 0)
    {
        $firstTimeInBasementPosition = $loopCounter
    }
}

Write-Host "Part 1: Santa is on floor $floor."
Write-Host "Part 2: Santa is in the basement for the first time on position $firstTimeInBasementPosition."
Write-Host ""

$RunTime = New-TimeSpan -Start $StartTime -End (get-date) 
Write-Host ("Execution time was {0} hours, {1} minutes, {2} seconds and {3} milliseconds." -f $RunTime.Hours,  $RunTime.Minutes,  $RunTime.Seconds,  $RunTime.Milliseconds)
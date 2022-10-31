<#
Advent of Code 2015
Day 01
  
Programmer: Andrew Stobart
Part 1 finished on October 30, 2022
Part 2

Code created using VS Code on both Mac and Windows.
#>

# Set variables
$floor = 0
$chars

$data = Get-Content ./input.txt
$chars = $data.ToCharArray()

foreach ($letter in $chars)
{
    if($letter -eq '(')
    {
        $floor++
    }
    else
    {
        $floor--
    }
}

write-host "Santa is on floor $floor."
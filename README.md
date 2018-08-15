# CS61A-1.7--Integer-partition-without-recursion
The number of partitions of a positive integer n, using parts up to size m, 
is the number of ways in which n can be expressed as the sum of positive integer 
parts up to m in increasing order. 
For example, the number of partitions of 6 using parts up to 4 is 9.  

6 = 2 + 4 

6 = 1 + 1 + 4 

6 = 3 + 3 

6 = 1 + 2 + 3 

6 = 1 + 1 + 1 + 3 

6 = 2 + 2 + 2 6 = 1 + 1 + 2 + 2 

6 = 1 + 1 + 1 + 1 + 2 

6 = 1 + 1 + 1 + 1 + 1 + 1 

As requested by the teacher of CS 61A, I will define a function Partitions(n, m) that returns the number of different partitions of n 
parts up to m, without using recursion. This is a simple C# Console version. It can also list all possible solutions as well.

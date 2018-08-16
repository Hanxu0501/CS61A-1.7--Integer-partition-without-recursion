# CS61A-1.7--Integer-partition-without-recursion
The number of partitions of a positive integer m, using parts up to size n, 
is the number of ways in which m can be expressed as the sum of positive integer 
parts up to n in increasing order. 
For example, the number of partitions of 6 using parts up to 4 is 9.  

6 = 2 + 4 

6 = 1 + 1 + 4 

6 = 3 + 3 

6 = 1 + 2 + 3 

6 = 1 + 1 + 1 + 3 

6 = 2 + 2 + 2 6 = 1 + 1 + 2 + 2 

6 = 1 + 1 + 1 + 1 + 2 

6 = 1 + 1 + 1 + 1 + 1 + 1 

As requested by the teacher of CS 61A, I will define a function Partitions(m, n) that returns the number of different partitions of m 
parts up to n, without using recursion. This is a simple C# Console version. It can also list all possible solutions as well.

Algorithm explained：

I use the idea of building a solution tree.

The root of the tree is dividing number N into N elements, each one has value of 1.

From this root, children and children's children are generated, by using a function called "Shrink".

A "father" have one more elements than his "children".

To generate a "child" from a "father", "Merge" function will take the last element from "father", and try to add its value to every elemnets ahead of it. By doing so, a new child is generated. However, we have to apply a filter to select "legal" child, and abandon bad ones. 

The selection rule is: 1. the value of changed elements (which receive the value from father's tail) should not exceed n (partition(m,n))

2. The value of changed elements should not be larger than the element ahead of it. (to keep the elements in decending order)

Merge function will return a list of "legal" children from a single father.

A "Merge" function will join all the children from all the fathers into a larger list. If two children from different fathers are idential, one of them will be disgarded. 

The finnal larger list which is returned from "Merge" will be store into a solution list (S), which is a list of list of list of integer. S[i] is the solutions with number of elements = n-i.

From those "legal" children, next gernation of children is produced in the same way, this is how "partition" function will do.

The maximum generation that "partition" will loop is m, but The "partition" function will stop and return total number of solutions when one of the generation has zero children.

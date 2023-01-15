# Linked List

Solves the problem of inserting into an array which is `O(N)` because all values from an old array need to be copied
into a new one.

## Complexity

- Insert/delete at front - `O(1)`
- Insert/delete at end - `O(N)`
- Insert/delete at middle - `O(N)`
- Search - `O(N)`
- Access by index - `O(N)`

## Use cases

- Dynamic arrays where the number of elements is not known or can change
- Implement abstract data types like stacks, queues, associative arrays, trees, hash tables, graphs.

## Flavors

### Singly linked list

A node contains a reference to the next node.

### Doubly linked list

A node contains a reference to the previous and next node. Allows efficient traversal in both directions.
Insert/delete at end - `O(1)`

### Circular linked list
A type of linked list in which the first and the last nodes are also connected to each other to form a circle

## Benefits:

- Dynamic sizing
- Allows values to be anywhere in the memory

## Drawbacks

- Requires more memory ergo can cause cache misses
- Random access is slow

## Examples

- OS keeps track of free and allocated memory blocks
- Undo/redo operations
- GC can track references with a linked list

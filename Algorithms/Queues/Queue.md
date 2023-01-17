# Queue

A queue is a data structure that stores a collection of elements
and follows the first-in, first-out (FIFO) principle.
Elements are added to the back of the queue (enqueued) and removed from the front of the queue (dequeued).

## Underlying data structure

Queues are usually implemented with doubly-linked list, which gives constant enqueue/dequeue time. 

## Complexity

- enqueue: O(1)
- dequeue: O(1)
- peek: O(1)
- is empty: O(1)

# Kafka

## Sequential I/O
Kafka uses append only log which writes data to the end of the file, which makes
access sequential.

- Sequential writes - 100 MB/s
- Random writes - 100 KB/s


## Zero Copy Principal

### No Zero Copy
Disk -> OS Cache -> Kafka -> Socket Buffer -> Network Interface Card (NIC) Buffer -> Consumer


### Zero Copy

Kafka uses a system call - `SendFile` to send data from OS Cache to NIC buffer

Data is copied via Direct Memory Access (DMA) where CPU is not involved

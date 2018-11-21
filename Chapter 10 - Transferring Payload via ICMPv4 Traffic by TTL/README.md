# Course : Bypassing Anti Viruses by C#.NET Programming

Part 2 (Infil/Exfiltration/Transferring Techniques by C#)  , Chapter 10 : Transferring Payload via ICMPv4 Traffic by TTL

eBook : Bypassing Anti Viruses by C#.NET Programming

eBook chapter 10 , PDF Download : https://github.com/DamonMohammadbagher/eBook-BypassingAVsByCSharp/tree/master/CH10

# NativePayload_ICMP.sh  help :

# Using this Method via two Linux systems (Linux only)

step1 (Linux system A with IPv4 192.168.1.10) : ./NativePayload_ICMP.sh shtext ”your text”

step2 (Linux system B with IPv4 192.168.1.13) : ./NativePayload_ICMP.sh listen 192.168.1.10

# Using this Method via one Linux system and one Windows system .

step1 (Linux system A with IPv4 192.168.1.10) : ./NativePayload_ICMP.sh shtext ”your text”

step2 (windows system B with IPv4 192.168.1.13) : ./NativePayload_ICMP.exe listen 192.168.1.10

Description: with Step1 (system A) you will inject bytes for "text" to TTL Values , with Step2 on (system B) you can have this text via Send/Rec ICMPv4 Traffic (Ping Response) 


Using this Method via two Linux systems (Linux only)
![](https://github.com/DamonMohammadbagher/NativePayload_ICMP/blob/master/Chapter%2010%20-%20Transferring%20Payload%20via%20ICMPv4%20Traffic%20by%20TTL/NativePayload_ICMP.png)

Using this Method via one Linux system and one Windows system .
![](https://github.com/DamonMohammadbagher/NativePayload_ICMP/blob/master/Chapter%2010%20-%20Transferring%20Payload%20via%20ICMPv4%20Traffic%20by%20TTL/NativePayload_ICMP(WindowsLinux).png)


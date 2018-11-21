 #!/bin/sh 

sudo sysctl net.ipv4.ip_default_ttl=254;
sleep 5;
TtlPayload="106109107104102107255107103102100106101106112106112102100106109106114107103106109106104106105102100106115106255106102100107109106115107105102114102100106109107104102107255107103102100106101106112106112102100106109106114107103106109106104106105102100106115106255106102100106113106105102100102114102114102114102100107109106115107105102100107255107106109106112106112102100107103106105106105";
                    for pay in `echo $TtlPayload | xxd -p -c 3`
                              do 
                                 str=`echo $pay | xxd -r -p`
                                 if [ "$str" != $'' ];
                                 then 
                                 echo "sudo sysctl net.ipv4.ip_default_ttl="$str "; sleep 2;"
                                 sudo sysctl net.ipv4.ip_default_ttl=$str; sleep 2;
                                 fi
                              done
sudo sysctl net.ipv4.ip_default_ttl=255; sleep 3;
sudo sysctl net.ipv4.ip_default_ttl=100; sleep 3;
sudo sysctl net.ipv4.ip_default_ttl=255; sleep 3;
sudo sysctl net.ipv4.ip_default_ttl=100; sleep 3;
sudo sysctl net.ipv4.ip_default_ttl=255; sleep 3;
sudo sysctl net.ipv4.ip_default_ttl=100; sleep 3;
sudo sysctl net.ipv4.ip_default_ttl=255; sleep 3;
sudo sysctl net.ipv4.ip_default_ttl=100; sleep 3;
sudo sysctl net.ipv4.ip_default_ttl=255; sleep 3;
sudo sysctl net.ipv4.ip_default_ttl=100; sleep 3;
sudo sysctl net.ipv4.ip_default_ttl=255; sleep 3;
sudo sysctl net.ipv4.ip_default_ttl=100; sleep 3;
sudo sysctl net.ipv4.ip_default_ttl=255; sleep 3;
sudo sysctl net.ipv4.ip_default_ttl=100; sleep 3;
sudo sysctl net.ipv4.ip_default_ttl=255;
echo "Done.";


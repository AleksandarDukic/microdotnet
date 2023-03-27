kada gadjamo iz Insomnia-je pod, ubacujemo localhost:[port NodePorta koji smo digli]
(kubectl get services)


Cluster u dokeru je vezan za HTTP
Ako nesto smestimo u Cluster on prakticno ima svoj HTTP port i prica sa drugim pod-om
Svi su oni u K8S klasteru ali se ponasaju kao da su dva apija i pricaju preko ClusterIP-a

zato na produkciji da bismo nasli drugi pod trazimo ga preko klaster servisa, npr:
   pravimo config fajl za produkciju sa produkcijskim rutama:
   {
    "CommandService": "http://commands-clusterip-srv:80/api/c/platforms/"
   }
To je zapravo adresa pomocnog ClusterIP servisa koji prosledjuje request odredjenom servisu u Podu.
  

tako da PlatformService gadja 
   "CommandService": "http://commands-clusterip-srv:80/api/c/platforms/"

jer ce kube staviti docker image u Cluster i dodelice mu id: commands-clusterip-srv

--------------------------------------------------------------------------------------------------------------------------------------------------
NGINX pod (koji se ponasa kao NODE PORT) koji je pod zasebnim namespaceom kad radi (kubectl get namespace)
se pokrece: kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.6.4/deploy/static/provider/cloud/deploy.yaml

Kada pokrenemo ove POD-ove, trazimo ih:   kubectl get pods --namespace==ingress-nginx
                                          kubectl get services --namespace=ingress-nginx

ingress-srv.yaml = to nam je routing fajl


NETWORKING za windows:
C:\Windows\System32\drivers\etc\hosts

i tu se doda: 127.0.0.1 acme.com

---------------------------------------------------------------------------------------------------------------------------------------------------

Pre rada sa bazom treba nam CLAIM = local-pvc.yaml
Koji se dobija: kubectl get pvc


DB:
   create secret generc mssql --from-litteral=SA_PASSWORD="pa55w0rd!"




-----------
Moras nauciti kako podesiti RabbitMQ u klasteru preko K8S(da bude sam u klasteru) !!!! 03:51:35
Moras nauciti kako da stavis dva servisa u jedan pod i jedan clusterIP.

--------------------------

I   2 docker fajla, 
      1 - mssql baza
      2 - lucene

      popuni za 50.000 stvari i proveri koja brze radi

II Kupi cluster na Linode-u kad zavrsis tutorijal




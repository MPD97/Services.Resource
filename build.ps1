docker build -t service.resource . ;
docker tag service.resource mateusz9090/resource:local ;
docker push mateusz9090/resource:local
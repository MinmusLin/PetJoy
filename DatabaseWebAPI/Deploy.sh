docker kill petjoy-databasewebapi
docker rm petjoy-databasewebapi
docker rmi minmuslin/petjoy-databasewebapi
docker pull minmuslin/petjoy-databasewebapi
docker run -d --name petjoy-databasewebapi --privileged -p 5101:8080 minmuslin/petjoy-databasewebapi
# stop runnin container(s)
docker ps -q --filter "name=qr-code" | xargs -r docker stop

# remove existing container(s)
docker ps -aq --filter "name=qr-code" | xargs -r docker rm

# remove unuse image
docker image prune -a

# rebuild qr-code
docker build --pull --no-cache -t qr-code . 

# start containrt
docker run --restart unless-stopped --name=qr-code -dp 52:80 -e ASPNETCORE_ENVIRONMENT=Development qr-code 
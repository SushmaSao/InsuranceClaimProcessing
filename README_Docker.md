# Commonly used Docker Commands

## Image and Containers
### Build image
`docker build` -t <imagename:tag> -f <docker_filepath> .
### List image
`docker image ls`

### List all containers
`docker ps -a`
### List running containers
`docker ps`
### Run container
#### Normal usage
`docker run` --name <container_name> -p <hostport:containerport> <image_name or image_id>
#### Detach mode
`docker run` --name <container_name> -d -p <hostport:containerport> <image_name or image_id>
#### With env variable
`docker run` --name <container_name> -d --env VARNAME = VALUE  -p <hostport:containerport> <image_name or image_id>
#### With env file
`docker run` --name <container_name> -d --env-file <file_name>  -p <hostport:containerport> <image_name or image_id>
### Check logs
`docker logs `<container_name or container_id>
### Shell container
`docker exec `-it <container_id> /bin/sh


## Network
### Create network
`docker network `create <network_name>
### Use network
`docker run `-d  --name <container_name> -p <hostport:containerport> --network <network_name> <image_name or image_id>
### List network
`docker network ls`
### Remove network
`docker network rm `<volume_name>


## Volume
### Create volume
`docker volume` create <volume_name>
### Use volume
`docker run `-d  --name <container_name> -p <hostport:containerport> --volume <volume_name>:<location_of_file> <image_name or image_id>
### List volume
`docker volume ls`
### Remove volume
`docker volume rm `<volume_name>


## Work with registry
### Login to registry
`docker login`
### Push image to registry
`docker push `<registry/imagename:tag> 
### Pull image from registry
`docker pull `<registry/imagename:tag> 
### Logout from registry
`docker logout`


## Docker Compose
### Build image
`docker compose` build 
### Start services
`docker compose `start
### Stop services
`docker compose `stop
### To build and run image together
`docker compose `up
### To stop
`docker compose `down
### Check logs
`docker compose logs`


## Other commands
`docker inspect` --type [image,volume,network,container] <type_name>


## Final Cleanup
`docker system prune`

`docker system prune -a --volumes`




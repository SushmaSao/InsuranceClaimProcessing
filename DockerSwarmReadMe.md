## Docker Swarm  
Docker Swarm is a  container orchestration platform that allows you to manage and scale a cluster of Docker nodes. 
It provides a way to deploy and run multiple containers across a distributed system, ensuring high availability and scalability.

## Initialized Swarm Cluster
	docker swarm init 

## Create Stack
	docker stack deploy -c compose.yaml insuranceclaim

## View the stack
	docker stack ls

## View the  services
	docker service ls

## Leave the swarm cluster
	docker swarm leave -f



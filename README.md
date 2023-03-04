## Architecture
### Scope
Ingest tick data and aggregated data from different sources via REST, SignalR, WebSockets, then push data to storage and send notifications.

### Microservice Diagram
![Microservice Diagram](https://github.com/quantarcanum/qarc.datafeed/blob/main/Qarc.DataFeed/Documentation/Diagram.png)

### Structure
Qarc.DataFeed Empty Solution

**CompositionRoot**

- Qarc.DataFeed.Startup (Console App) 
  - Entry point for starting Qarc.DataFeed.Adaptor.Api
  - Dirty CompositionRoot project hooking up dependencies for the whole microservice code   
- Qarc.DataFeed.Adaptor.Api (ASP.NET Core Web API) 
- Qarc.DataFeed.Adaptor.Mongo (ClassLibrary) 
  - Add MongoDb.Driver nuget
  
**Adaptors**

- Qarc.DataFeed.Adaptor.Api (ASP.NET Core Web API) 
- Qarc.DataFeed.Adaptor.Mongo (ClassLibrary)
- Qarc.DataFeed.Adaptor.Kafka (ClassLibrary)

**Core**

- Qarc.DataFeed.Core.Domain (ClassLibrary)
- Qarc.DataFeed.Core.Application (ClassLibrary)  

### Dependency Graph

## Tech Debt

 - Add CompositionRoot project for bootstrapping and REMOVE mongo & kafka project dependencies form API project!!!!
 - Point datafeed to Write mongo instance after cluster is ready
 - Add composion to models and write custom serializer for mongo mapper and also adjust automapper
 - Add input model fluent validation
 - Add Security
 - Environment Variables and Secrets after setting up CICD
 - Add logging & tracing w/ correlation token after setting up the infrastructure in kubernetes 
 - Tests

## Deployment
### Manual Deployment Steps

_In order to get the latest dockerfile (with all project references) just copy the ports from it, delete it, Add / Docker Support , then paste back the ports._

#### 1. Build a local Docker Image
>_Dockerfile contains some absolute paths to the projects so for this specific project I need to cd inside one dir above the API that holds the Dockerfile resides._
```
cd C:\Coding\repos\quantarcanum\qarc.datafeed\Qarc.DataFeed  
docker build -f C:\Coding\repos\quantarcanum\qarc.datafeed\Qarc.DataFeed\Qarc.DataFeed.Adapter.Api\Dockerfile -t qarc-datafeed .

docker images     // check if it's created
```

#### 2. Run a local Docker Container using the Image we've just built
``` 
//docker run -d -p external_port:internal_port image_name
docker run -d -p 3230:80 -p 3231:443 qarc-datafeed

// a few other commands for container manipulation
docker ps -a                                         // list all containers (in order to get the container id)
docker stop container_ID                             // stop container
docker start -i container_id/cointainer_name         // start container
docker exec -it container_ID bash                    // log into a contianer
docker exit                                          // log out of a contianer
docker rm -a container_ID                            // delete a container
```

#### 3. Push the Docker Image to Dockerhub
>_On docker hub we have a limitation that it only allows for one private repository. So in order to store multiple images we will use the same image name with different tags. Instead of using the tag to provide the version v1.0.0 we will use the tag as the "image name"._

Login to dockerhub
```
docker login
```
The private repository on docker hub is called: pete3m/quantarcanum and we can push repositories/images to it by running:
``` 
docker push pete3m/quantarcanum:tagname
``` 
The local repository/image on my machine is called: qarc-datafeed
<br>I need to create another repository/image from it, to match the upstream repository name (specifying the image name as tag) 
<br>Using the docker commit command I can create a new image based on an existing container: 
``` 
//docker commit container_ID docker_username/upstream_repository_name:tag_optional
docker commit 2f5cccaedeb7 pete3m/quantarcanum:qarc-datafeed                   // get container_id from step 2
``` 
Now check if created (run "docker images"): you should have an image with: 
- REPOSITORY pete3m/quantarcanum 
- TAG qarc-datafeed

Push the new repository by running: 
``` 
docker push docker_username/image_name:tag

docker push pete3m/quantarcanum:qarc-datafeed
```  
Now you can check [docker hub](https://hub.docker.com/repository/docker/pete3m/quantarcanum/general) 

You can pull a docker image by running:
``` 
docker pull image_name
```  

#### 4. Deploy Service in Kubernetes from dockerhub

Create Kubernetes Deployment, Service & Ingressroute yamls and push to upstream
 - Set Deployment to pull the image from Dockerhub
 - In service.yaml specify ClusterIP and expose 80 and 443
 - In ingressroute create rules for all controllers matching the host and url controller name like so:  
   - match: Host(`qarc.tplinkdns.com`) && Path(`/api/AtasGuerrillaAggregatedData/{*}`)
 - Make sure the url points to kubernetes loadbalancer ip (sudo nano /etc/hosts)

Pull from server and cd into Kubernetes folder where the yamls reside and run
 
 ```
sudo k3s kubectl create -f deployment.yaml
sudo k3s kubectl create -f service.yaml
sudo k3s kubectl create -f ingress.yaml
 ```
 

## Dependency Graph


## Tech Debt

 - Add CompositionRoot project for bootstrapping and REMOVE mongo & kafka project dependencies form API project!!!!
 - Point datafeed to Write mongo instance after cluster is ready
 - Add composion to models and write custom serializer for mongo mapper and also adjust automapper
 - Add input model fluent validation
 - Add Security
 - Add logging & tracing w/ correlation token after setting up the infrastructure in kubernetes 
 - Tests

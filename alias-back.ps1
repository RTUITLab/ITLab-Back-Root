function BackendDockerCompose {
    docker-compose `
        -f .\docker-compose.yml `
        -f .\docker-compose.override.yml `
 `
        -f .\ITLab-Identity\docker-compose.yml `
        -f .\ITLab-Identity\docker-compose.override.yml `
 `
        $args
}

Set-Alias -Name bdc BackendDockerCompose

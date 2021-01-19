# ITLab-Back-Root
Root config for ITLab-back

Proxy Back

[![Build Status](https://dev.azure.com/rtuitlab/RTU%20IT%20Lab/_apis/build/status/ITLab/ITLab-Back-Root?branchName=master)](https://dev.azure.com/rtuitlab/RTU%20IT%20Lab/_build/latest?definitionId=142&branchName=master)

Services in backend part:
| Service        | Status      | Available on                               | Inner port            | CI/CD              |
| -------------- | ----------- | ------------------------------------------ | --------------------- | ------------------ |
| Identity       | Done        | http://127.0.0.1.xip.io:5501               | 5501                  | :white_check_mark: |
| Identity Admin | Done        | http://127.0.0.1.xip.io:5502               | 5502                  | :white_check_mark: |
| Backend        | Done        | http://127.0.0.1.xip.io:5503/api/          | 5503                  | :white_check_mark: |
| DocsGen        | Done        | http://127.0.0.1.xip.io:5503/api/docsgen/  | 8080 (should be 5504) | :white_check_mark: |
| Projects       | Done        | http://127.0.0.1.xip.io:5503/api/projects/ | 5505                  | :white_check_mark: |
| Reports        | Done        | http://127.0.0.1.xip.io:5503/api/reports/  | 5506                  | no                 |
| MFS            | Done        | http://127.0.0.1.xip.io:5503/api/mfs/      | 5507                  | no                 |
| Salary         | Done        | -                                          | -                     | no                 |
| Notify         | In progress | -                                          | -                     | no                 |

In local mode, Cookie with same-site ignored on http connection by default in chrome-based browsers. Select **"Disable"** in chrome config `Cookies without SameSite must be secure` chrome://flags/#cookies-without-same-site-must-be-secure

## Build

### Build apps
```bash
./build
```

### Set environment variables:
* ITLABPROJ_GH_ACCESS_TOKEN - Personal Access Token from github for access to private repos on GitHub [link](https://github.com/settings/tokens).

> While developing you can create `env.ps1` or `env.sh` files. They have already been ignored.
> Powershell example
> ```powershell
> $Env:ITLABPROJ_GH_ACCESS_TOKEN='YOUR TOKEN'
> ```
> Bash example
> ```bash
> export ITLABPROJ_GH_ACCESS_TOKEN='YOUR TOKEN'
> ```
> And apply env to current session
> ```bash
> . ./env.ps1
> # or
> . ./env.sh
> ```

### Build docker images

```bash
. ./alias-back.ps1 # alias for docker compose
dbc build --no-cache
```

## Run services

```bash
bdc up -d
```
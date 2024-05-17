# Job Candidate API

- [Job Candidate API](#job-candidate-api)
  - [Create Candidate](#create-candidate)
    - [Create Candidate Request](#create-candidate-request)
    - [Create Candidate Response](#create-candidate-response)
  - [Update Candidate](#update-candidate)
    - [Update Candidate Request](#update-candidate-request)
    - [Update Candidate Response](#update-candidate-response)

## Create Candidate

### Create Candidate Request

```js
POST /candidates/create
```

```json
{
    "firstName": "Hamza",
    "lastName": "SRAIDI",
    "phoneNumber": "+212601053319",
    "email": "hamzasraidi08@gmail.com",
    "preferredCallTime": "2024-05-17T12:00:00",
    "linkedIn_Profile_Url": "https://www.linkedin.com/in/hamzasraidi/",
    "github_Profile_Url": "https://github.com/HamzaSry1",
    "comment": "Job Application for Junior .NET Developer at Sigma Software"
}
```

### Create Candidate Response

```json
{
    "Status": 201,
    "Data": {
        "firstName": "Hamza",
        "lastName": "SRAIDI",
        "phoneNumber": "+212601053319",
        "email": "hamzasraidi08@gmail.com",
        "preferredCallTime": "2024-05-17T12:00:00",
        "linkedIn_Profile_Url": "https://www.linkedin.com/in/hamzasraidi/",
        "github_Profile_Url": "https://github.com/HamzaSry1",
        "comment": "Job Application for Junior .NET Developer at Sigma Software"
    },
    "Message": "Candidate information has been added successfully."
}
```

or 

```json
{
    "Status": 400,
    "Data": null,
    "Message": "Bad Request: Invalid input data. Please check your request parameters."
}
```


## Update Candidate

### Update Candidate Request

```js
PUT /candidates/update
```

```json
{
    "firstName": "Hamza Edited",
    "lastName": "SRAIDI Edited",
    "phoneNumber": "+212601053319",
    "email": "hamzasraidi08@gmail.com",
    "preferredCallTime": "2024-05-17T12:00:00",
    "linkedIn_Profile_Url": "https://www.linkedin.com/in/hamzasraidi/",
    "github_Profile_Url": "https://github.com/HamzaSry1",
    "comment": "Job application for Junior .NET Developer at Sigma Software"
}
```

### Update Candidate Response

```json
{
    "Status": 200,
    "Data": {
        "firstName": "Hamza Edited",
        "lastName": "SRAIDI Edited",
        "phoneNumber": "+212601053319",
        "email": "hamzasraidi08@gmail.com",
        "preferredCallTime": "2024-05-17T12:00:00",
        "linkedIn_Profile_Url": "https://www.linkedin.com/in/hamzasraidi/",
        "github_Profile_Url": "https://github.com/HamzaSry1",
        "comment": "Job application for Junior .NET Developer at Sigma Software"
    },
    "Message": "Candidate information has been updated successfully."
}
```

or 

```json
{
    "Status": 404,
    "Data": null,
    "Message": "Not Found: Candidate information with provided email does not exist."
}
```

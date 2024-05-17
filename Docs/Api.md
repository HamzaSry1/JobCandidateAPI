# Job Candidate API

- [Job Candidate API](#job-candidate-api)
  - [Get All Candidates](#get-all-async)
    - [Get All Candidates Request](#get-all-candidates-request)
    - [Get All Candidates Response](#get-all-candidates-response)
  - [Get Candidate by Email](#get-by-emailasyncemail)
    - [Get Candidate by Email Request](#get-candidate-by-email-request)
    - [Get Candidate by Email Response](#get-candidate-by-email-response)
  - [Create Candidate](#createasync)
    - [Create Candidate Request](#create-candidate-request)
    - [Create Candidate Response](#create-candidate-response)
  - [Update Candidate](#updateasync)
    - [Update Candidate Request](#update-candidate-request)
    - [Update Candidate Response](#update-candidate-response)
  - [Delete Candidate](#deleteasyncemail)
    - [Delete Candidate Request](#delete-candidate-request)
    - [Delete Candidate Response](#delete-candidate-response)

## Get All Candidates

### Get All Candidates Request

```
POST /candidates/getAllAsync
```

```
{
    "PageNumber": 1,
    "PageSize": 10,
    "OrderBy": "firstName",
    "OrderByDirection": "asc"
}
```


###  Get All Candidates Response

```
{
    "Data": [
        {
        "firstName": "Hamza",
        "lastName": "SRAIDI",
        "phoneNumber": "+2120601053319",
        "email": "Hamzasraidi08@gmail.com",
        "preferredCallTime": "2024-05-17T12:00:00",
        "linkedIn_Profile_Url": "https://www.linkedin.com/in/hamzasraidi/",
        "github_Profile_Url": "https://github.com/HamzaSry1",
        "comment": "Job application for junior .NET developer at Sigma Software "
        },
    ],
    "RecordTotal": 1,
    "RecordFiltered": 1
}
```


## Get Candidate by Email
## Get Candidate by Email Request

```
GET /candidates/getByEmailAsync/{email}
```

## Get Candidate by Email Response

```
{
    "status": 200,
    "message": "Candidate found.",
    "data": {
        "firstName": "Hamza",
        "lastName": "Sraidi",
        "phoneNumber": "+2120601053319",
        "email": "Hamzasraidi08@gmail.com",
        "preferredCallTime": "2024-05-17T16:45:52.485Z",
        "linkedIn_Profile_Url": "https://www.linkedin.com/in/hamzasraidi/",
        "github_Profile_Url": "https://github.com/HamzaSry1",
        "comment": "Job application for junior .NET developer at Sigma Software"
    },
    "validationErrors": null
}
```

or 

```
{
    "status": 404,
    "message": "Not Found: Candidate information with provided email does not exist."
}
```

## Create Candidate
## Create Candidate Request

```
POST /candidates/createAsync
```

```
{
    "firstName": "Hamza",
    "lastName": "Sraidi",
    "phoneNumber": "+2120601053319",
    "email": "Hamzasraidi08@gmail.com",
    "preferredCallTime": "2024-05-17T16:45:52.485Z",
    "linkedIn_Profile_Url": "https://www.linkedin.com/in/hamzasraidi/",
    "github_Profile_Url": "https://github.com/HamzaSry1",
    "comment": "Job application for junior .NET developer at Sigma Software"
}
```

## Create Candidate Response

```
{
  "message": "Candidate information has been added successfully.",
  "status": 201,
  "data": {
    "firstName": "Hamza",
    "lastName": "Sraidi",
    "phoneNumber": "+2120601053319",
    "email": "Hamzasraidi08@gmail.com",
    "preferredCallTime": "2024-05-17T16:45:52.485Z",
    "linkedIn_Profile_Url": "https://www.linkedin.com/in/hamzasraidi/",
    "github_Profile_Url": "https://github.com/HamzaSry1",
    "comment": "Job application for junior .NET developer at Sigma Software"
  },
  "validationErrors": null
}
```

or

```
{
    "Status": 400,
    "Message": "Bad Request: Invalid input data. Please check your request parameters."
}
```

or 

```
{
  "status": 400,
  "validationErrors": [
    {
      "propertyName": "Email",
      "errorMessage": "Email must not be empty."
    },
    {
      "propertyName": "Email",
      "errorMessage": "Invalid email format."
    }
  ]
}
```

## Update Candidate
## Update Candidate Request

```
PUT /candidates/updateAsync
```

```
{
    "firstName": "Hamza  EDITED",
    "lastName": "Sraidi EDITED",
    "phoneNumber": "+2120601053319",
    "email": "Hamzasraidi08@gmail.com",
    "preferredCallTime": "2024-05-17T16:45:52.485Z",
    "linkedIn_Profile_Url": "https://www.linkedin.com/in/hamzasraidi/",
    "github_Profile_Url": "https://github.com/HamzaSry1",
    "comment": "Job application for junior .NET developer at Sigma Software EDITED"
}
```

## Update Candidate Response

```
{
  "message": "Candidate information has been updated successfully.",
  "status": 200,
  "data": {
    "firstName": "Hamza  EDITED",
    "lastName": "Sraidi EDITED",
    "phoneNumber": "+2120601053319",
    "email": "Hamzasraidi08@gmail.com",
    "preferredCallTime": "2024-05-17T16:45:52.485Z",
    "linkedIn_Profile_Url": "https://www.linkedin.com/in/hamzasraidi/",
    "github_Profile_Url": "https://github.com/HamzaSry1",
    "comment": "Job application for junior .NET developer at Sigma Software EDITED"
  },
  "validationErrors": null
}
```

or

```
{
    "status": 404,
    "message": "Not Found: Candidate information with provided email does not exist."
}
```

or 

```
{
  "status": 400,
  "validationErrors": [
    {
      "propertyName": "Email",
      "errorMessage": "Email must not be empty."
    },
    {
      "propertyName": "Email",
      "errorMessage": "Invalid email format."
    }
  ]
}
```

## Delete Candidate
## Delete Candidate Request

```
DELETE /candidates/deleteAsync/{email}
```


## Delete Candidate Response

```
{
    "status": 200,
    "message": "Candidate information has been deleted successfully.",
    "data": {
        "firstName": "Hamza",
        "lastName": "SRAIDI",
        "phoneNumber": "+2120601053319",
        "email": "Hamzasraidi08@gmail.com",
        "preferredCallTime": "2024-05-17T12:00:00",
        "linkedIn_Profile_Url": "https://www.linkedin.com/in/hamzasraidi/",
        "github_Profile_Url": "https://github.com/HamzaSry1",
        "comment": "Job application for junior .NET developer at Sigma Software "
    },
    "validationErrors": null
}
```

or 

```
{
    "status": 404,
    "message": "Not Found: Candidate information with provided email does not exist."
```
}
# Ghibli Suggestion API
A simple API that fetches Studio Ghibli films and provides movie suggestions based on mood, length, and pairing. 

Features caching for faster responses.

## Features:
- Fetch all the films from API
- Get specific film from API
- Suggest film with parameters (very basic algorithm for now)

## Endpoints:
- `GET /api/films` - List all films
- `GET /api/films/{id}` - Get a specific film _id should be guid_
- `GET /api/suggest` - Get a film suggestion

## Future Improvements:
- Implement more advanced suggestion algorithm (e.g., consider genres, director, or ratings trends)
- Search
- Pagination
- Logging
- Option to refresh cache manually or automatically
- Just overall expand the api (different focuses and such)
---
https://ghibliapi.vercel.app/ is the API used for info about movies
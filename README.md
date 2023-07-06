# Тестовое задание

Проект содержит файл со скриптом базы данных (`games.sql`). Также база данных может быть восстановлена с помощью `Update-Database`.

## Описание методов api 
### Получение списка жанров
#### URL запроса 
```
GET /api/Genres/get
```
#### Параметры метода
Метод не имеет параметров
#### Возвращаемое значение 
`200` - возвращает список жанров  
Пример ответа:
```js
[
  {
    "id": 1,
    "genreName": "Survival"
  },
  {
    "id": 2,
    "genreName": "Horror"
  },
  {
    "id": 3,
    "genreName": "Action-RPG"
  },
  {
    "id": 4,
    "genreName": "Adventure"
  },
  {
    "id": 5,
    "genreName": "Sandbox"
  }
]
```
### Получение списка студий
#### URL запроса
```
GET /api/Developers/get
```
#### Параметры метода
Метод не имеет параметров
#### Возвращаемое значение 
`200` - возвращает список студий  
Пример ответа:
```js
[
  {
    "id": 1,
    "name": "Capcom"
  },
  {
    "id": 2,
    "name": "Id Software"
  },
  {
    "id": 3,
    "name": "Blizzard"
  },
  {
    "id": 4,
    "name": "Mojang Studios"
  }
]
```
### Получение списка игр 
#### URL запроса
```
GET /api/Games/get
```
#### Параметры метода
Метод не имеет параметров
#### Возвращаемое значение 
`200`  - возвращает список игр  
Пример ответа: 
```js
[
  {
    "id": 1,
    "title": "Resident Evil Village",
    "developer": "Capcom",
    "developerId": 1,
    "genres": [
      {
        "id": 1,
        "genreName": "Survival"
      },
      {
        "id": 2,
        "genreName": "Horror"
      }
    ]
  },
  {
    "id": 2,
    "title": "Monster Hunter: World",
    "developer": "Capcom",
    "developerId": 1,
    "genres": [
      {
        "id": 3,
        "genreName": "Action-RPG"
      }
    ]
  },
  {
    "id": 3,
    "title": "Sekiro: Shadows Die Twice",
    "developer": "Id Software",
    "developerId": 2,
    "genres": [
      {
        "id": 3,
        "genreName": "Action-RPG"
      },
      {
        "id": 4,
        "genreName": "Adventure"
      }
    ]
  },
  {
    "id": 4,
    "title": "Dark Souls 3",
    "developer": "Id Software",
    "developerId": 2,
    "genres": [
      {
        "id": 3,
        "genreName": "Action-RPG"
      },
      {
        "id": 4,
        "genreName": "Adventure"
      }
    ]
  }
]
```
### Получение списка игр по жанру
#### URL запроса
```
GET /api/Games/get/{genreId}
```
#### Параметры метода
`GenreId` - id жанра, целое число
#### Возвращаемое значение
`200` - возвращает список игр определенного жанра .Если жанра не существует - возвращает пустой список  
Пример ответа(`/api/Games/get/3`):
```js
[
  {
    "id": 2,
    "title": "Monster Hunter: World",
    "developer": "Capcom",
    "developerId": 1,
    "genres": [
      {
        "id": 3,
        "genreName": "Action-RPG"
      }
    ]
  },
  {
    "id": 3,
    "title": "Sekiro: Shadows Die Twice",
    "developer": "Id Software",
    "developerId": 2,
    "genres": [
      {
        "id": 3,
        "genreName": "Action-RPG"
      },
      {
        "id": 4,
        "genreName": "Adventure"
      }
    ]
  },
  {
    "id": 4,
    "title": "Dark Souls 3",
    "developer": "Id Software",
    "developerId": 2,
    "genres": [
      {
        "id": 3,
        "genreName": "Action-RPG"
      },
      {
        "id": 4,
        "genreName": "Adventure"
      }
    ]
  },
  {
    "id": 5,
    "title": "Diablo",
    "developer": "Blizzard",
    "developerId": 3,
    "genres": [
      {
        "id": 3,
        "genreName": "Action-RPG"
      }
    ]
  }
]
```
### Добавление игры 
#### URL запроса
```
POST /api/Games/add
```
#### Параметры метода 
Телом запроса передаётся объект:
```js
{
  "title": "string",
  "developerId": 0,
  "genres": [
    {
      "id": 0,
    }
  ]
}
```
- `title` - название игры;
- `developerId` - id студии;
-  `genres` - массив жанров, для каждого жанра достаточно указать только id.

Пример запроса:
```js
{
  "title": "test",
  "developerId": 1,
  "genres": [
    {
      "id": 1
    },
    {
      "id": 2
    }
  ]
}
```
#### Возвращаемое значение 
- `200` с добавленым объектом типа `Game` - успешное добавление игры;
- `400` - ошибка валидации;
- `404` с описанием не найденного id - неправльный id студии или жанра.

Пример ответа с кодом `200`:
```js
{
  "id": 42,
  "title": "test",
  "developer": "Capcom",
  "developerId": 1,
  "genres": [
    {
      "id": 1,
      "genreName": "Survival"
    },
    {
      "id": 2,
      "genreName": "Horror"
    }
  ]
}
```

### Изменение игры 
#### URL запроса
```
PUT /api/Games/update
```
#### Параметры метода
Телом запроса передаётся объект:
```js
{
  "id": "int",
  "title": "string",
  "developerId": 0,
  "genres": [
    {
      "id": 0,
    }
  ]
}
```
- `id` - id объекта для которого происходит изменение;
- `title` - название игры;
- `developerId` - id студии;
-  `genres` - массив жанров, для каждого жанра достаточно указать только id.

Пример запроса:
```js
{
  "id" : 42,
  "title": "changed",
  "developerId": 1,
  "genres": [
    {
      "id": 5
    },
    {
      "id": 2
    }
  ]
}
```
#### Возвращаемое значение
- `200` с изменнёным объектом типа `Game` - успешное изменение игры ;
- `400` - ошибка валидации;
- `404` с описанием не найденного id - неправльный id студии, жанра или игры.
Пример ответа с кодом `200`:  
```js
{
  "id": 42,
  "title": "changed",
  "developer": "Capcom",
  "developerId": 1,
  "genres": [
    {
      "id": 5,
      "genreName": "Sandbox"
    },
    {
      "id": 2,
      "genreName": "Horror"
    }
  ]
}
```
### Удаление игры 
#### URL запроса
```
DELETE /api/Games/remove/{gameId}
```
#### Параметры метода
`gameId` - id игры, целое число
#### Возвращаемое значение 
- `200` - успешное удаление игры ;
- `404` с описанием не найденного id - неправльный id игры.

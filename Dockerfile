services:
  api:
    build:
      context: .
      dockerfile: Dockerfile
    ports:
      - "5000:80"
    depends_on:
      - db

  db:
    image: mariadb:10.4.24
    environment:
      MYSQL_ROOT_PASSWORD: 303304
      MYSQL_DATABASE: fotovoltaico
    ports:
      - "3306:3306"

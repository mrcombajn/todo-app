<script setup>
import Todo from './components/Todo.vue'
</script>

<template>
  <nav>
    <section id="title">Todo list by Mateusz Ostrowski</section>
    <section id="image">
      <img src="./components/icons/bell.png" alt="notification-icon">
    </section>
  </nav>

  <main>
    <Todo/>
  </main>
</template>

<style scoped>

nav {
  display: inline-flex;
  margin: 0;
  background-color: #2AACE6;
  width: 100%;
  padding: 10;
  color: black;
}

section {
  padding: 10px;
  color: white;
  letter-spacing: 1.5px;
}

section#title {
  width: 25%;
}

section#image {
  display: flex;
  justify-content: flex-end;
  width: 75%;
}

section > img {
  height: 24px;
  width: 24px;
}

main {
  display: flex;
}

</style>

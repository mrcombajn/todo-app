<template>
  <main>
    <header>
        <p>{{ title }}</p>
    </header>
    <section>
        <p>{{ description }}</p>
    </section>
    <section>
        <p>{{ date }}</p>
    </section>

    <button @click="$emit('emitDeleteTodo')">Usuń zadanie</button>
    <button @click="$emit('emitEditTodo')">Edytuj</button>
  </main>
</template>

<script>
  export default {
    props: ['title', 'description', 'date']
  }
</script>
<style scoped>

main{
    border: 1px solid black;
    display: flex;
    flex-direction: column;
}


</style>

<script setup>

import Todo from './Todo.vue';

</script>

<template>
    <section v-if="todos.length == 0">Ups! niczego tutaj nie ma :/ Dodaj nowe zadanie</section>
    <section v-else>
      <Todo v-for="todo in todos"
         :title="todo.title"
         :description="todo.description"
         :date="todo.date"
         @emitDeleteTodo="$emit('deleteTodoFromDb', todo.id)"
         @emitUpdateTodo="(todoData) => $emit('editTodoInDb', todo.id, todoData)"></Todo>
    </section>
</template>

<script>
    export default {
        props: ['todos'],
        components: {
            Todo
        },
    }
</script>

<style lang="css" scoped>


</style>
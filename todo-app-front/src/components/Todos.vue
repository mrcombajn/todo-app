<template>
    <main>
        <section v-if="todos.length == 0">Ups! niczego tutaj nie ma :/ Dodaj nowe zadanie</section>
        <section v-if="isAddingTodo">
            <Todo :isAdding="true"/>
        </section>
        <section v-else>
        <Todo v-for="todo in todos"
            :title="todo.title"
            :description="todo.description"
            :date="todo.date"
            @emitDeleteTodo="$emit('deleteTodoFromDb', todo.id)"
            @emitUpdateTodo="(todoData) => $emit('editTodoInDb', todo.id, todoData)"></Todo>
        </section>
    </main>
</template>

<script>
    import Todo from './Todo.vue';

    export default {
        data() {
            return {
                isAddingTodo: false
            }
        },
        props: ['todos'],
        components: {
            Todo
        },
        methods: {
            triggerAddTodo() {
                this.isAddingTodo = true
            }
        }
    }
</script>

<style lang="css" scoped>

main {
    padding: 20px;
}

</style>
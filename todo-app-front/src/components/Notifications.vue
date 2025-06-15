<template>
  <div>
    <div v-if="upcomingTasks.length > 0" class="notification">
      Masz {{ upcomingTasks.length }} zbliżających się zadań!
    </div>
  </div>
</template>

<script>
export default {
  props: {
    todos: []
  },
  data() {
    return {
      upcomingTasks: []
    }
  },
  mounted() {
    this.checkTasks()
    this.interval = setInterval(this.checkTasks, 60000)
  },
  beforeDestroy() {
    clearInterval(this.interval)
  },
  methods: {
    checkTasks() {

    }
  }
}
</script>

<style scoped>

</style>
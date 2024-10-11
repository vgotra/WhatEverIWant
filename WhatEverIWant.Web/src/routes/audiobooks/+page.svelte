<script>
	import ListPage from '$lib/components/ListPage.svelte';
	import Item from '$lib/components/Item.svelte';
</script>

<ListPage apiEndpoint="/api/audiobooks" itemComponent={Item} />

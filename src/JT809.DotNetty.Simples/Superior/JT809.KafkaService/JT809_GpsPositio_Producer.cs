﻿using Confluent.Kafka;
using Google.Protobuf;
using JT809.GrpcProtos;
using JT809.PubSub.Abstractions;
using Microsoft.Extensions.Options;

namespace JT809.KafkaService
{
    public sealed class JT809_GpsPositio_Producer : JT809Producer<JT809GpsPosition>
    {
        protected override IJT809ProducerPartitionFactory ProducerPartitionFactory { get; }

        protected override Serializer<JT809GpsPosition> Serializer => (position) => position.ToByteArray();

        protected override JT809PartitionOptions PartitionOptions { get; }

        public JT809_GpsPositio_Producer(IOptions<ProducerConfig> producerConfigAccessor)
            : this(producerConfigAccessor,null, null )
        {

        }

        public JT809_GpsPositio_Producer(
            IOptions<ProducerConfig> producerConfigAccessor,
            IJT809ProducerPartitionFactory partitionFactory,
            IOptions<JT809PartitionOptions> partitionAccessor
          ):base(producerConfigAccessor.Value)
        {
            ProducerPartitionFactory = partitionFactory;
            PartitionOptions = partitionAccessor?.Value;
        }
    }
}